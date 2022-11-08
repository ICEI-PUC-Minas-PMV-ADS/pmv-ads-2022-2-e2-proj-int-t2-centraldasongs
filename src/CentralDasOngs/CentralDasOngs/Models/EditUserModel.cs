namespace CentralDasOngs.Models
{
    public class EditUserModel
    {
        public int Id { get; set; }
        public UserOngModel userOngModel { get; set; }
        public UserModel userModel { get; set; }


        public EditUserModel(int id, UserOngModel userOngModel, UserModel userModel)
        {
            Id = id;
            this.userOngModel.About = userOngModel.About;
            this.userOngModel.BankAccount = userOngModel.BankAccount;

            this.userModel.Name = userModel.Name;
            this.userModel.Contact = userModel.Contact;
            this.userModel.Address = userModel.Address;
        }
    }
}
