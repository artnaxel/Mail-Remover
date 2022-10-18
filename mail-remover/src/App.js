import React from 'react'
import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Layout from './components/layout/Layout'
import AddNewEmail from './pages/addNewEmail/AddNewEmail'

function App () {
  return (

  <BrowserRouter>
    <Layout>
      <div className="App">
        <Routes>
          <Route path="/" element={<AddNewEmail/>}/>
        </Routes>
      </div>
    </Layout>
  </BrowserRouter>

  )
}

export default App
