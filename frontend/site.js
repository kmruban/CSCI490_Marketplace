
function myFunction() {
  alert('Later, this will create a user');
}

var User = {

  UserName: "",
  FirstName: "",
  LastName: "",
  Email: "",
  Password: "",
  CreditCardInfo_CardNumber: ""

}
function createAccountClick() {
  // Build user object from inputs
  User = new Object();
  User.UserName = $("#uname").val();
  User.FirstName = $("#fname").val();
  User.LastName = $("#lname").val();
  User.Email = $("#email").val();
  User.Password = $("#pword").val();
  User.CreditCardInfo_CardNumber = $("#cnum").val();

    userAdd(User);
  }

  function userAdd(user) {
    $.ajax({
      url: "https://localhost:5001/User",
      type: 'POST',
      contentType: 
         "application/json;charset=utf-8",
      data: JSON.stringify(user),

      success: console.log("Sucess!"),
      error:  console.log("Not sucessfull")
    })}