import React from 'react';
import { AppBar, Box, Button, Container, Toolbar, Typography } from "@mui/material";
import {Link} from 'react-router-dom';

export default function NavBar(){
    return(
        <AppBar position="static">
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Typography 
                    variant="h6"
                    noWrap
                    sx={{
                        mr:2,
                        display: {xs:'none', md:'flex'},
                        fontFamily:'monospace',
                        fontWeight: 700,
                        letterSpacing: '.3rem',
                        color:'inherit',
                        textDecoration: 'none'

                    }}>
                    <Link className='text-link' to="/">FlashyLearn</Link>
                    </Typography>
                    <Box sx={{flexGrow:1, display:{xs:'none', md:'flex'}}}>
                        <Button key="Categories" sx={{my:2, color:'white', display:'block '}}>
                            <Link className='text-link' to="/categories">Categories</Link>
                        </Button>
                        <Button key="FlashCards" sx={{my:2, color:'white', display:'block '}}>
                            <Link className='text-link' to="/flashcards">FlasCards</Link>
                        </Button>
                    </Box>
                </Toolbar>
            </Container>
        </AppBar>
    )
}