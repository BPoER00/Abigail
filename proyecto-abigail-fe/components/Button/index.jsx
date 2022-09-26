import styles from "./styles.module.css";

export default function Button({ children, type = "button", handleClick = () => {} }) {
  return (
    <button className={styles.btn} type={type} onClick={handleClick}>
      {children}
    </button>
  );
}
