import Logo from "components/Logo";

import styles from "./styles.module.css";

export default function LogoWithName({ color = false }) {
  return (
    <span className={styles.logoLarge}>
      <Logo width="56" height="42" />
      <span className={`${styles.label} ${color && styles.blueLabel}`}>Abigail</span>
    </span>
  );
}
