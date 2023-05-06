import React from "react"

class TodoItem extends React.Component
{
    constructor()
    {
        super()
        this.state = {
            count:0,
            a:3
        }
        this.handleClick = this.handleClick.bind(this)
    }

    handleClick(){
        this.setState((prevState) => {
            console.log(this.state.a)
            return {
                count:prevState.count+1
            }
        })
    }

    render()
    {
        return (
            <div>
                <h1>
                    {this.state.count}
                </h1>
                <button onClick={this.handleClick}>ClickMe</button>
            </div>
        )
    }
}

export default TodoItem