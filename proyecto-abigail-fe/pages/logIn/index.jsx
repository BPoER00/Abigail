import FormLogIn from "components/FormLogIn";
import Logo from "components/Logo";
import Link from "next/link";
import styles from "./style.module.css";

export default function LogIn() {
  return (
    <section className={styles.container}>
      <article className={styles.containerLogIn}>
        <header className={styles.header}>
          <Logo />
          <h1 className={styles.title}>Inicio de sesión</h1>
        </header>
        <FormLogIn />
        <footer>
          <Link href="/">
            <a className={styles.lostPassword}>Olvidé mi contraseña</a>
          </Link>
        </footer>
      </article>
    </section>
  );
}
