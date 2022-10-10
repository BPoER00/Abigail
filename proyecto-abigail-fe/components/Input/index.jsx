import styles from "./styles.module.css";

export default function Input({
  label = "",
  type = "text",
  name = "",
  placeholder = "",
  maxLength = "100",
  required = false,
  value = undefined,
  onChange = null,
}) {
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
        autoComplete="off"
        maxLength={maxLength}
        required={required}
        value={value}
        onChange={onChange}
      />
    </div>
  );
}
