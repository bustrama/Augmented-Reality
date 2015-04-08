function checkFirstName(fName) {
    if (fName == "" || fName == null) {
        alert("Enter first name!");
        return false;
    }
    var antiSymbols = "!@#$%^&*()_+=-~`;,./\|></'{}[]";
    var antiNumbers = "1234567890";
    var name = fName;
    var validity = true;
    var checkChar;

    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiNumbers.length; j++) {
            if (checkChar == antiNumbers.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiSymbols.length; j++) {
            if (checkChar == antiSymbols.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    if (validity) {
        return true;
    } else {
        alert("First Name must contain letters only !");
        return false;
    }
}

function checkLastName(lName) {
    if (lName == "" || lName == null) {
        alert("Enter last name!");
        return false;
    }
    var antiSymbols = "!@#$%^&*()_+=-~`;,./\|></'{}[]";
    var antiNumbers = "1234567890";
    var name = lName;
    var validity = true;
    var checkChar;

    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiNumbers.length; j++) {
            if (checkChar == antiNumbers.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiSymbols.length; j++) {
            if (checkChar == antiSymbols.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    if (validity) {
        return true;
    } else {
        alert("Last Name must contain letters only !");
        return false;
    }
}

function checkUserName(userName) {
    if (userName == "" || userName == null) {
        alert("Enter user name!");
        return false;
    } if (userName.length > 20) {
        alert("User name is too long!");
        return false;
    }
    var antiSymbols = "!@#$%^&*()_+=-~`;,./\|></'{}[]";
    var name = userName;
    var validity = true;
    var checkChar;

    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiSymbols.length; j++) {
            if (checkChar == antiSymbols.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    if (validity) {
        return true;
    } else {
        alert("User Name cannot contain these special charecters!");
        return false;
    }
}

function checkPassword(pass, repass) {
    if (pass == "" || pass == null) {
        alert("Enter user name!");
        return false;
    } if (pass.length > 35) {
        alert("Password is too long!");
        return false;
    }
    if (pass != repass) {
        alert("Password doesn't math!");
        return false;
    }
}

function checkEmail(email) {
    if (email == "" || email == null) {
        alert("Enter eMail!");
        return false;
    } if (email.length > 53) {
        alert("eMail Adress is too long!");
        return false;
    }
    var antiSymbols = "-_~!$&'()*+,;=: ";
    var name = email;
    var validity = true;
    var checkChar;

    for (var i = 0; i < name.length; i++) {
        checkChar = name.charAt(i);
        for (var j = 0; j < antiSymbols.length; j++) {
            if (checkChar == antiSymbols.charAt(j)) {
                validity = false;
                break;
            }
        }
    }
    if (validity) {
        return true;
    } else {
        alert("eMail Adress cannot conatin these special charecters!");
        return false;
    }
}