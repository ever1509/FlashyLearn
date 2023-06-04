import React from 'react';
import { Outlet } from "react-router-dom";
import NavBar from './nav/NavBar';
import { Container } from '@mui/material';

export default function Layout(){
    return (<>
        <NavBar />
        <Container sx={{p:'2rem'}} >
            <Outlet />
        </Container>
    </>);
}