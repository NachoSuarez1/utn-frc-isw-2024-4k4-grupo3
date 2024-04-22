import { Link } from "react-router-dom";
import "./css/NavBar.css";

export const NavBar = () => {
  return (
    <nav className="nav-bar">
      <ul>
        <li>
          <Link className="nav-item" to="/quotes">
            Cotizaciones de mis Pedidos
          </Link>
        </li>
      </ul>
    </nav>
  );
};
