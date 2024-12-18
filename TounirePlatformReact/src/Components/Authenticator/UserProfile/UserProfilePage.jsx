import React from "react";
import UserProfile from "./UserProfile";
import './UserProfilePage.css';

const UserProfilePage = () => {
    const user = JSON.parse(localStorage.getItem("loggedInUser"));

    const handleLogout = () => {
        localStorage.removeItem("loggedInUser"); 
        window.location.href = "/auth"; 
    };

    return (
        <div className="userProfilePage">
            <header className="header">
            <div className="logo">
            Tournament
            <svg viewBox="0 0 64 64" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width=""></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <g id="Flat"> <g id="Color"> <polygon fill="#000000" points="22.94 30.38 35.06 37.38 21.06 61.62 18 52.93 8.94 54.62 22.94 30.38"></polygon> <path d="M22.94,30.38l-5.61,9.71c1.14,2.23,4,2.84,6.17,2.75a7.85,7.85,0,0,1,2.15.21c1.48.6,2.87,2.1,4.61,2.64l4.8-8.31Z" fill="#111315"></path> <polygon fill="#000000" points="41.06 30.38 28.94 37.38 42.94 61.62 46 52.93 55.06 54.62 41.06 30.38"></polygon> <path d="M41.06,30.38l-12.12,7,4.8,8.31c1.74-.54,3.13-2,4.61-2.64a7.89,7.89,0,0,1,2.15-.21c2.16.09,5-.53,6.17-2.75Z" fill="#111315"></path> <polygon fill="#dd051d" points="31.58 35.37 19.31 56.65 18 52.93 14.11 53.66 26.4 32.38 31.58 35.37"></polygon> <polygon fill="#dd051d" points="49.9 53.66 46 52.93 44.69 56.66 32.42 35.37 37.6 32.38 49.9 53.66"></polygon> <path d="M37.6,32.38l-5.18,3,4.79,8.3c1.78-1.39,4.12-.49,6.25-1.14Z" fill="#a60416"></path> <path d="M26.4,32.38,20.54,42.53c2.13.65,4.47-.25,6.25,1.14l4.79-8.3Z" fill="#a60416"></path> <path d="M50.55,23.5c0-2.11,1.57-4.44,1-6.34S48.2,14.24,47,12.6s-1.3-4.48-3-5.69-4.35-.42-6.32-1S34.11,3,32,3s-3.83,2.24-5.73,2.86-4.68-.14-6.32,1-1.75,4-3,5.69-3.85,2.59-4.49,4.56.95,4.23.95,6.34-1.57,4.44-.95,6.34S15.8,32.76,17,34.4s1.3,4.48,3,5.69,4.35.42,6.32,1S29.89,44,32,44s3.83-2.24,5.73-2.86,4.68.14,6.32-1,1.75-4,3-5.69,3.85-2.59,4.49-4.56S50.55,25.61,50.55,23.5Z" fill="#fccd1d"></path> <circle cx="32" cy="23.5" fill="#f9a215" r="14.5"></circle> <path d="M33.37,16l1.52,2.63a1.54,1.54,0,0,0,1.06.76L39,20a1.53,1.53,0,0,1,.85,2.56l-2.1,2.22a1.5,1.5,0,0,0-.4,1.22l.36,3a1.57,1.57,0,0,1-2.22,1.58l-2.81-1.27a1.6,1.6,0,0,0-1.32,0l-2.81,1.27A1.57,1.57,0,0,1,26.31,29l.36-3a1.5,1.5,0,0,0-.4-1.22l-2.1-2.22A1.53,1.53,0,0,1,25,20l3-.59a1.54,1.54,0,0,0,1.06-.76L30.63,16A1.59,1.59,0,0,1,33.37,16Z" fill="#fccd1d"></path> </g> </g> </g></svg>
        </div>
                <nav className="nav">
                    <button className="navButton">Матчі</button>
                    <button className="navButton">Турніри</button>
                    <button className="navButton">Команди</button>
                    <button className="navButton">Гравці</button>
                    <button className="navButton"onClick={() => window.location.href = "/games"}>Ігри</button>
                </nav>
                <div className="userActions">
                    <button className="iconButton" onClick={() => window.location.href = "/profile"}>👤</button>
                    <button className="iconButton" onClick={handleLogout}>🚪</button>
                </div>
            </header>
            <h1 className="H1">Профіль Користувача</h1>
            <main className="mainContent">
                {user ? (
                    <UserProfile user={user} onLogout={handleLogout} />
                ) : (
                    <p>Вам потрібно увійти, щоб побачити профіль.</p>
                )}
            </main>
        </div>
    );
};

export default UserProfilePage;
