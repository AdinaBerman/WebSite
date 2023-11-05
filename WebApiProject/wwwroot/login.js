//Rename file...

//const showRregister () => {
//    const reg = document.getElementById("visibilityRegister")
//    reg.
//}
const login = async () => {

    try {
        const userName = document.getElementById("username").value
        const password = document.getElementById("password").value
        const res = await fetch(`api/Users?userName=${userName}&password=${password}`)

        if (res.status == 204)
            window.alert("userName or password are not valid")
         //if res.status==400 - validation errors (model validations- entity)
        else {
            const user = await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href = "update.html"
        }

    } catch (e) {
        //Fetch throws error only when network errors occurre, 400 and 500 status code you must check!!
        //Note: according to the way you implemented getUser - it doesn't return 400... 
        window.alert("user not found");
        throw e;
    }
}

const register = async () => {
    const user = {
        UserName: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("FirstName").value,
        lastName: document.getElementById("LastName").value
    }
    //const User = { UserName:userName, Password:password, FirstName:firstName, LastName:lastName }, Prefix -UpperCase

    const checkIfStrong = await checkStrongPassword()
    //checkStrongPassword alert this message.
    if (checkIfStrong == 1) {
        alert("Please enter strong password!")
    }
    //checkStrongPassword should return True/False. If False- alert (easy password )and exit the function

    try {
        const res = await fetch('api/Users',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)

            })
        if (!res.ok)
            alert("Sorry, we couldn't add you to our site, Try again")
        else {
            const data = await res.json()
            alert(`user ${data.userName} registered succfully`)
        }
    }

    catch (err) {
        //? log the error to console...
        throw err;
    }
}

const checkStrongPassword = async () => {

    const strongPass = document.getElementById("passwordRegister").value
    const progressValue = document.getElementById("progressValue")

    try {
        const res = await fetch('api/Users/checkStrongPassword',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(strongPass)

            })
        if (res.status == 204)//change in controller to BadRequest and here to 401 status code\
            //return alert???
            //return True/False and handle it in register function 
            return alert("Your password isn't strong, enter a new one")

        const score = await res.json()
        progressValue.value = score;

        //?? Your api already checked if the score smaller than 2...
        //
        if (score > 2) {
            return 0;
        }
        else {
             alert("Easy password... Enter a new one!")
            return 1;
        }

    }
    catch (err) {
        throw err;
    }
}

