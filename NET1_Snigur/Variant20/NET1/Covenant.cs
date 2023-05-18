using DOTNET.Variant20.NET2.XMLConverter.VariableNames;
using System;
using System.Xml.Serialization;

namespace DOTNET.Variant20.NET1
{
    [Serializable, XmlRoot(ElementName = CovenantVariableNames.BaseName)]
    public class Covenant
    {
        [XmlAttribute(AttributeName = CovenantVariableNames.Id)]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = CovenantVariableNames.Deposit)]
        public decimal Deposit { get; set; }

        public void CheckDate()
        {
            try
            {
                if (ReturnDate <= DateTime.Today)
                {
                    Deposit = default;
                }
            }
            catch (ArgumentNullException) { };
        }

        private decimal IntermediatPrice { get; set; }

        [XmlAttribute(AttributeName = CovenantVariableNames.Price)]
        public decimal Price 
        { 
            get 
            { 
                return IntermediatPrice; 
            }
            set
            {
                Car car = Data.Cars[CarCovenant.CarId];

                IntermediatPrice = (ReturnDate - IssueDate).Days * 
                    (100 - (DateTime.Today.Year - car.Year)) *
                    car.Price / 250;
            }
        }

        [XmlAttribute(AttributeName = CovenantVariableNames.IssueDate)]
        public DateTime IssueDate { get; set; }

        [XmlAttribute(AttributeName = CovenantVariableNames.ReturnDate)]
        public DateTime ReturnDate { get; set; }

        [XmlAttribute(AttributeName = CovenantVariableNames.CarId)]
        public int CarId { get; set; }
        public CarCovenant CarCovenant => new CarCovenant(CarId, Id);

        [XmlAttribute(AttributeName = CovenantVariableNames.ClientId)]
        public int ClientId { get; set; }
        public ClientCovenant ClientCovenant => new ClientCovenant(ClientId, Id);

        public Covenant() { }
        //Long parameter list 
        public Covenant(int Id, int ClientId, int CarId, DateTime IssueDate, DateTime ReturnDate)
        {
            this.Id = Id;
            this.ClientId = ClientId;
            this.CarId = CarId;
            this.IssueDate = IssueDate;
            this.ReturnDate = ReturnDate;

            Price = IntermediatPrice;
            Deposit = Data.Cars[CarId].Price / 50m;
        }

        public override string ToString()
        {
            return "Client №" + ClientId + " took car №" + CarId + " from " + IssueDate.ToString("yyyy.MM.dd") + " to " + ReturnDate.ToString("yyyy.MM.dd");
        }
    }
}
