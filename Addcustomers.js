import React, { useState } from "react";


const Addcustomers = () => {
  const [custName, setcustName] = useState("");
  const [contName, setContName] = useState("");
  const [custAdd, setCustAdd] = useState("");
  const [citynew, setCitynew] = useState("");
  const [pstcode, setpstcode] = useState("");
  const [cunt, setcunt] = useState("");
  const [newstate, setNewState] = useState("");

  const handleCustnamechange = (event) => {
    setcustName(event.target.value);
  };

  const handleContactaNameChange = (event) => {
    setContName(event.target.value);
  };
   
  const handleCustomersAddressChange = (event) => {
    setCustAdd(event.target.value);
  };

  const handleCityChange = (event) => {
    setCitynew(event.target.value);
  };

  const handlePostalCodeChange = (event) => {
    setpstcode(event.target.value);
  };

  const handleCountryChange = (event) => {
    setcunt(event.target.value);
  };

  const handleStsateChange = (event) => {
    setNewState(event.target.value);
  };
  //for saving the details of customers (browser ->dB)

  const handleCustomerSaveFetch = async () => {
    const url = new URL("http://localhost:5278/api/Customers/SaveCustomers");
    url.searchParams.append("CustomerName", custName);
    url.searchParams.append("ContactName", contName);
    url.searchParams.append("CoustmerAddress", custAdd);
    url.searchParams.append("City", citynew);
    url.searchParams.append("PostalCode", pstcode);
    url.searchParams.append("Country", cunt);
    url.searchParams.append("States", newstate);

    try {
      // Sending the GET request with the query parameters
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      });
      //checking is the response is working or not
      if (!response.ok) {
        throw new Error("failed to save Customers");
      }
      // If successful, get the response and display success message
      const result = await response.json();
      if (result === true) {
        alert("Saved Successfully");
      } else {
        alert("An error occured while saving customers"); 
      }
    } catch (error) {
      console.error("Error:", error);
      console.log("error occured ,we cant Save the Data");
    }
  };

  return (
    <div className="Customer">
      <div>
        <label>
          <strong>Customer Name:</strong>
        </label>
        <input
          type="text"
          onChange={handleCustnamechange}
          value={custName}
        ></input>{" "}
      </div>
      <div>
        <label>Contact Name:</label>
        <input
          type="text"
          onChange={handleContactaNameChange}
          value={contName}
        ></input>{" "}
      </div>
      <div>
        <label>CustomerAddress: </label>
        <input
          type="text"
          onChange={handleCustomersAddressChange}
          value={custAdd}
        ></input>
      </div>
      <div>
        <label>City:</label>
        <input
          type="text"
          onChange={handleCityChange}
          value={citynew}
          placeholder="enter city Name"
        ></input>
      </div>
      <div>
        <label>PostalCode:</label>
        <input
          type="text"
          onChange={handlePostalCodeChange}
          value={pstcode}
          placeholder="Enter Postal Code"
        ></input>
      </div>
      <div>
        <label>Country:</label>
        <input
          type="text"
          onChange={handleCountryChange}
          value={cunt}
          placeholder="your Country Name"
        ></input>
      </div>

      <div>
        <label>State</label>
        <input
          type="text"
          onChange={handleStsateChange}
          value={newstate}
          placeholder="States"
        ></input>
      </div>
      <br />
      <button onClick={handleCustomerSaveFetch}>Save Customer</button>
    </div>
  );
};

export default Addcustomers;
