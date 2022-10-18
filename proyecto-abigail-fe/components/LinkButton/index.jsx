import Link from "next/link";

import styles from "./styles.module.css";

export default function LinkButton({ children, href = "/" }) {
  return (
    <Link className={styles.btn} href={href}>
      <a className={styles.btn}>{children}</a>
    </Link>
  );
}
