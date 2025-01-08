using GymApp.DTO;
using GymApp.Models;
using GymApp.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Resources;

namespace GymApp.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public  Task<byte[]> CreatePdfConfirmation(GetUsersReservationsDTO reservation)
        {
            return Task.Run(() =>
            {
                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);

                        page.Header()
                        .PaddingHorizontal(2, QuestPDF.Infrastructure.Unit.Centimetre)
                        .Text("Training reservation confirmation")
                        .Bold()
                        .FontSize(30)
                        .FontColor(Colors.Blue.Medium)
                        .AlignCenter();
                        

                        page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);

                        page.Content()                        
                        .Text($"Reservation Date: {reservation.ReservationDate}\n" +
                              $"Training Name: {reservation.Training.Name}\n" +
                              $"Training Description: {reservation.Training.Description}\n" +
                              $"Training Start Date: {reservation.Training.StartDate}\n")
                        .FontColor(Colors.Black).FontSize(12);

                        

                        page.Footer()
                        .AlignCenter()
                        .Text("Order document has been generate automaticly. " + "Copyright © 2023 GymApp Inc. All Rights Reserved ")
                        .FontColor(Colors.Grey.Darken1);

                    });
                });

                return  document.GeneratePdf();
            
            });
        }
    }
}
