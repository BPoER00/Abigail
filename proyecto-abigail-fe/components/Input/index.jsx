import styles from "./styles.module.css";

export default function Input({ label = "", type = "text", name = "", placeholder = "", required = false }) {
  return (
    <div className={styles.inputContainer}>
      {label && (
        <label className={styles.label} htmlFor={name}>
          {label}
        </label>
      )}
      <input
        className={styles.input}
        type={type}
        name={name}
        id={name}
        placeholder={placeholder}
        autocomplete="off"
        required={required}
      />
    </div>
  );
}
