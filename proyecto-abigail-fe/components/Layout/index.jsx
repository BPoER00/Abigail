import AsideMenu from "components/AsideMenu";
import Header from "components/Header";
import styles from "./styles.module.css";

export default function Layout({ children, currentPage = false }) {
  return (
    <div className={styles.container}>
      <AsideMenu currentPage={currentPage} />
      <main className={styles.mainContainer}>
        <Header />
        <section className={styles.content}>{children}</section>
      </main>
    </div>
  );
}
