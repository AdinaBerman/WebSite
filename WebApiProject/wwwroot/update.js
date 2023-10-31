const update = async () => {

    const user = {
        UserName: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("FirstName").value,
        lastName: document.getElementById("LastName").value
    }

    try {
        const userJson = sessionStorage.getItem("user")
        const id = JSON.parse(userJson).userId
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

const userToHello = sessionStorage.getItem("user");
const userToHelloJSON = JSON.parse(userToHello)
const hello = document.getElementById("hello")
hello.innerHTML = `Hello ${userToHelloJSON.firstName}! Welcome to our site!`

