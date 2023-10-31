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
        UserName: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("FirstName").value,
        lastName: document.getElementById("LastName").value
    }

    const checkIfStrong = await checkStrongPassword()

    if (checkIfStrong == 1) {
        alert("Please enter strong password!")
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
            alert(`user ${data.userName} registered succfully`)
        }
    }

    catch (err) {
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
        if (res.status == 204)
            return alert("Your password isn't strong, enter a new one")

        const score = await res.json()
        progressValue.value = score;

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

