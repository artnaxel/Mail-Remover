import { TextField, Paper, Box } from '@mui/material'
import React from 'react'
import Style from './AddNewEmailForm.module.css'

export default function AddNewEmailForm () {
  return <Box
    display="flex"
    justifyContent="center"
  >
    <Paper className={Style.Paper} elevation={3}>
      <TextField label="Email" variant="outlined"/>
    </Paper>
  </Box>
}
