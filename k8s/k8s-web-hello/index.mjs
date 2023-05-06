import express from 'express'
import os from 'os'

const app = express()
const PORT = 3000

app.get('/',req,res=>{
    const hellomessage = `Hello from the ${os.hostname()}`
    console.log(hellomessage)
    res.setEncoding(hellomessage)
})

app.listen(PORT,() =>{
    console.log(`Web server is listening at PORT ${PORT}`)
})