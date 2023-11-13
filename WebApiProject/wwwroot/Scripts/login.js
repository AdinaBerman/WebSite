

//const showRregister () => {
//    const reg = document.getElementById("visibilityRegister")
//    reg.
//}

//const userToHello = sessionStorage.getItem("user");
//const userToHelloJSON = JSON.parse(userToHello)
//const hello = document.getElementById("hello")
//hello.innerHTML = `Hello ${userToHelloJSON.FirstName}! Welcome to our site!`

const login = async () => {

    try {
        const userName = document.getElementById("username").value
        const password = document.getElementById("password").value
        const res = await fetch(`api/Users?userName=${userName}&password=${password}`)

        if (res.status == 400)
            alert("Error in connection DB")
        else if (res.status == 204)
            window.alert("userName or password are not valid")
        else {
            const user = await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href = "update.html"
        }

    } catch (e) {
        window.alert("user not found");
        throw e;
    }
}

const register = async () => {
    const user = {
        Email: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        FirstName: document.getElementById("FirstName").value,
        LastName: document.getElementById("LastName").value
    }

    const checkIfStrong = await checkStrongPassword()

    if (!checkIfStrong) {
        return alert("Please enter strong password!");
    }

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
            alert(`user ${data.FirstName} ${data.LastName} registered succfully`)
        }
    }

    catch (err) {
        console.log(err);
    }
}

const update = async () => {

    const user = {
        UserId: 0,
        Email: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        FirstName: document.getElementById("FirstName").value,
        LastName: document.getElementById("LastName").value
    }

    const checkIfStrong = await checkStrongPassword()

    if (!checkIfStrong) {
        return alert("Please enter strong password!");
    }

    try {
        const userJson = sessionStorage.getItem("user")
        console.log(userJson);
        const id = JSON.parse(userJson).userId
        user.UserId = id;
        const res = await fetch(`api/Users/${id}`,
            {
                method: 'PUT',
                headers: { 'Content-Type': `application/json` },
                body: JSON.stringify(user)
            })
        if (!res.ok)
            alert("error updated to the server,please try again!")
        else {

            alert(`user ${id} updated succfully`)
        }

    } catch (e) {
        alert(e)
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
        if (!res.ok)
            return false;

        const score = await res.json()
        if(progressValue != null)
            progressValue.value = score;

        if (score >= 2) {
            return true;
        }
        else {
             alert("Easy password... Enter a new one!")
            return false;
        }

    }
    catch (err) {
        throw err;
    }
}

