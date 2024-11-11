import React, { useEffect, useState } from 'react';
import './GameList.css';

const GamesList = () => {
    const [games, setGames] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [userRole, setUserRole] = useState(''); 

    useEffect(() => {
        const fetchGames = async () => {
            try {
                const response = await fetch('http://localhost:5030/Games/GamesList', {
                    method: 'GET',
                    headers: {
                        'Accept': 'text/plain'
                    }
                });
                
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                setGames(data); 
            } catch (error) {
                setError(error.message); 
            } finally {
                setLoading(false); 
            }
        };

        const fetchUserRoleFromLocalStorage = () => {
            const loggedInUser = localStorage.getItem('loggedInUser'); 
            if (loggedInUser) {
                const user = JSON.parse(loggedInUser); 
                setUserRole(user.role);
                console.log("User Role from local storage:", user.role); 
            }
        };

        fetchGames();
        fetchUserRoleFromLocalStorage(); 
    }, []); 

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>; 
    }

    return (
        <div className='J'>
            <h1>Games List</h1>
            <ul>
                {games.map((game) => (
                    <li key={game.id}>
                        <h2>{game.name}</h2>
                    </li>
                ))}
            </ul>
            {userRole === 'admin' && (
                <button className="add-game-button"onClick={() => window.location.href = "/games/create"}>Додати гру</button>
            )}
        </div>
    );
};

export default GamesList;
