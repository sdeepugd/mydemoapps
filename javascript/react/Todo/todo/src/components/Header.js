import React from "react"

const Header = () => {
    var firstname = "Deepak"
    var date = new Date()
    const hours = date.getHours()
    let timeofDay

    if(hours <12){
        timeofDay = "morning"
    } 
    else 
    {
        timeofDay = "evening"
    }

    const styles = {
        color:"#FF8C00",
    }

const combinedstyle = {...styles,...{backgroundColor:"#FF2D00"}}

if(timeofDay==="evening"){
    combinedstyle.backgroundColor = "#000"
}

    return (
        <div className="navbar">
            <header >Hello {`${firstname}`}</header>
            <h5 style={combinedstyle}>
            Good {`${timeofDay}`}
            </h5>
        </div>
        
    )
}

export default Header
