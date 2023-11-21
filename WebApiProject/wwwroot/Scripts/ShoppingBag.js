let itemCount = 0;// document.getElementById("itemCount");
const prodInBag = [];
let totalAmount = 0;

const allInBag = () => {
    let i = 0;
    while (sessionStorage.getItem(`product ${i}`) != null) {
        let p = sessionStorage.getItem(`product ${i}`); 
        prodInBag.push(JSON.parse(p));
        i++;
    }
    console.log(prodInBag)
}

const showProducts = async () => {

    for (let i = 0; i < prodInBag.length; i++) {
        //const tmp = document.querySelector("template");
        //console.log(tmp);
        //const clone = tmp.content.cloneNode(true);
        //clone.querySelector("imageColumn").src = "/pictures/" + prodInBag[i].image;
        //clone.querySelector("h1").innerText = prodInBag[i].prodName;
        //clone.querySelector(".price").innerText = prodInBag[i].prodPrice;
        //clone.querySelector(".descriptionColumn").innerText = prodInBag[i].prodDescription;
        //document.getElementById("tbody").appendChild(clone);
        totalAmount += prodInBag[i].prodPrice;
        itemCount++;
    }
    document.getElementById("itemCount").value = itemCount;
    document.getElementById("totalAmount").value = totalAmount;
}

const placeOrder = async () => {
    if (!sessionStorage.getItem("user"))
        window.location.href = "homePage.html";

    let orderItemsArr = [];

    for (let i = 0; i < prodInBag.length; i++) {
        if (orderItemsArr.find(p => p.ProductId == prodInBag[i].productId)) {
            const o = orderItemsArr.find(p => p.ProductId == prodInBag[i].productId);
            o.Quentity += 1;
        }
        else {
            let orderItem = {
                ProductId: prodInBag[i].productId,
                Quentity: 1
            }
            orderItemsArr.push(orderItem);   
        }
    }

    const user = sessionStorage.getItem("user");
    const userJson = JSON.parse(user);

    const order = {
        OrderDate: new Date(),
        UserId: userJson.userId,
        OrderSum: itemCount,
        OrderItems: orderItemsArr
    }

    addOrderToDB(order);
}

const addOrderToDB = async (order) => {
    
    try {
        const res = await fetch('api/Orders',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(order)

            })
        if (!res.ok)
            alert("Sorry, your order isn't created, Try again")
        else {
            const data = await res.json()
            alert(`order ${data.id} added succfully`)
        }
    }

    catch (err) {
        console.log(err);
    }
}


allInBag();
showProducts();

