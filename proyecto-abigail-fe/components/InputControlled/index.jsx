import { useState } from "react";
import Input from "components/Input";
import Image from "next/image";

import styles from "./styles.module.css";

export default function InputControlled({
  label = "",
  type = "text",
  name = "",
  placeholder = "",
  maxLength = "100",
  required = false,
}) {
  const [value, setEraseText] = useState("");

  const onChangeInput = (event) => {
    setEraseText(event.target.value);
  };

  return (
    <div className={styles.inputContainer}>
      <Input
        label={label}
        type={type}
        name={name}
        id={name}
        placeholder={placeholder}
        autoComplete="off"
        maxLength={maxLength}
        required={required}
        value={value}
        onChange={onChangeInput}
      />
      <button onClick={() => setEraseText("")} type="button">
        <Image src="/icons/erase.svg" width={32} height={32} alt="Borrar texto" />
      </button>
    </div>
  );
}
