import { Link } from "react-router-dom";
import "./css/NavBar.css";

export const NavBar = () => {
  return (
    <nav className="nav-bar">
      <ul>
        <li>
          <Link className="nav-item" to="/quotes/1234">
            Cotizaciones de mi ultimo pedido
          </Link>
        </li>
      </ul>
    </nav>
  );
};
