import React from 'react'
import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Layout from './components/layout/Layout'
import AddNewUser from './pages/addNewEmail/AddNewUser'

function App () {
  return (
    <BrowserRouter>
      <Layout>
        <div className="App">
          <Routes>
            <Route path="/" element={<AddNewUser/>}/>
          </Routes>
        </div>
      </Layout>
    </BrowserRouter>

  )
}

export default App
