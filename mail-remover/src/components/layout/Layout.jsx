import React from 'react'
import Header from '../header/Header'
import Proptypes from 'prop-types'

export default function Layout ({ children }) {
  return (
        <>
            <Header/>
            <main>{children}</main>
        </>
  )
}

Layout.propTypes = {
  children: Proptypes.element
}
