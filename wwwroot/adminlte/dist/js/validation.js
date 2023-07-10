$(document).ready(function() {
    $("#errorMessage").hide();

    
    $("#form").submit(function(event) {
      var password = $("#contra").val();
      var confirmPassword = $("#confirmar").val();

      
      if (password !== confirmPassword) {
        $("#errorMessage").show();
        event.preventDefault();
      }
    });
  });