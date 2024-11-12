
import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import Tasks from './components/Tasks';

function App() {
  return (
    <Router>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <ul className="navbar-nav">
                    {/* Add new menu items here. */}
                    <li className="nav-item">
                        <Link className="nav-link" to="/">Tasks</Link>
                    </li>
                </ul>
            </nav>
            <div className="container mt-3">
                <Routes>
                  {/* Add new app pages here. */}
                  <Route path="/" element={<Tasks />} />
                </Routes>
            </div>
        </Router>
  );
}

export default App;
