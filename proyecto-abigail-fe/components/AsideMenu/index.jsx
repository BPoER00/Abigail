import { SettingsIcon } from "components/Icons";
import LogoWithName from "components/LogoWithName";
import Image from "next/image";
import Link from "next/link";
import ItemMenu from "./ItemMenu";
import styles from "./styles.module.css";

export default function AsideMenu({ currentPage = false }) {
  return (
    <aside className={styles.aside}>
      <header className={styles.headerAside}>
        <Link href={"/home"}>
          <LogoWithName />
        </Link>
        <button className={styles.bthHidden}>
          <Image src={"/icons/left-arrow.svg"} width={24} height={24} alt="Ocultar menú" />
        </button>
      </header>
      <nav className={styles.nav}>
        <ul className={styles.ul}>
          <ItemMenu currentPage={currentPage} />
        </ul>
      </nav>
      <Link href={"/config"}>
        <a className={styles.config}>
          <SettingsIcon />
          <span>Configuraciones</span>
        </a>
      </Link>
    </aside>
  );
}
