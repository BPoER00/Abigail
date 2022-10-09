import { MoonIcon, SunIcon } from "components/Icons";
import Image from "next/image";
import styles from "./styles.module.css";

export default function Header() {
  return (
    <header className={styles.header}>
      <button className={styles.btn} type="button">
        <MoonIcon />
        <SunIcon stroke="#3661eb" />
      </button>
      <div className={styles.containerSearch}>
        <button className={styles.searchInput} type="button">
          <img src="/icons/search.svg" alt="" />
          Buscar
        </button>
      </div>
      <Image className={styles.avatar} src={"/images/carlos-iglesias.jpg"} width={48} height={48} alt="Avatar" />
    </header>
  );
}
