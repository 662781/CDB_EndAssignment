using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using AzureFunctions.Service.Interfaces;
using System.Net;
using System.Net.Mail;

namespace AzureFunctions.Service
{
    public class MortgageService : IMortgageService
    {
        private readonly IMortgageRepo _mortgageRepo;

        public MortgageService(IMortgageRepo mortgageRepo)
        {
            _mortgageRepo = mortgageRepo;
        }
        public void GenerateOffers(List<MortgageApplication> pendingApplications)
        {
            // Generate mortgage offers and store them in the database
            foreach (MortgageApplication application in pendingApplications)
            {
                Mortgage mortgage = new Mortgage()
                {
                    DepositAmount = CalcDepositAmt(application.Buyer.MonthlyIncome),
                    LoanAmount = CalcLoanAmt(application.Buyer.MonthlyIncome),
                    LoanTermMonths = CalcLoanTermMonths(application.Buyer.MonthlyIncome),
                    InterestRate = CalcInterestRate(application.Buyer.MonthlyIncome),
                    BuyerID = application.BuyerID,
                    HouseID = application.HouseID
                };

                _mortgageRepo.Create(mortgage);
            }
        }

        public void NotifyBuyers(List<Mortgage> todaysMortgages)
        {
            foreach (Mortgage m in todaysMortgages)
            {
                SendEmail(m);
            }
        }

        public List<Mortgage> GetAllFromToday()
        {
            return _mortgageRepo.GetAllFromToday();
        }

        public void SendEmail(Mortgage m)
        {
            //string smtpServer = "your-smtp-server.com";
            //int smtpPort = 587;
            //string smtpUsername = "your-username";
            //string smtpPassword = "your-password";

            //SmtpClient smtpClient = new SmtpClient(smtpServer)
            //{
            //    Port = smtpPort,
            //    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            //    EnableSsl = true,
            //};

            //// Create the email message
            //MailMessage message = new MailMessage
            //{
            //    From = new MailAddress("your-email@example.com"),
            //    Subject = "Your Mortgage Offer",
            //    IsBodyHtml = true,
            //    Body = $"Dear {m.Buyer.FirstName} {m.Buyer.LastName},\n\n" +
            //           $"We are pleased to offer you the following mortgage:\n\n" +
            //           $"Offer Details: {m}\n\n" +
            //           "Thank you for choosing our services.",
            //};

            //// Set the recipient email address
            //message.To.Add(m.Buyer.Email);

            //// Send the email
            //smtpClient.Send(message);
        }

        public double CalcDepositAmt(double income)
        {
            return 0.0;
        }

        public double CalcLoanAmt(double income)
        {
            return 0.0;
        }

        public int CalcLoanTermMonths(double income)
        {
            return 0;
        }

        public double CalcInterestRate(double income)
        {
            return 0.0;
        }
    }
}