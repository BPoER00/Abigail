import { RadioGroup } from "@headlessui/react";
import { useState } from "react";

import styles from "./styles.module.css";

/**
 *
 * @param {Un array de objetos que contenga un id y un name} param0
 * @returns
 */
export default function RadioOptions({ OPTIONS, title = "", name = "modalidad" }) {
  let [selected, setSelected] = useState(OPTIONS[0]);

  return (
    <RadioGroup name={name} className={styles.containerGroup} value={selected} onChange={setSelected}>
      <RadioGroup.Label className={styles.label}>{title}</RadioGroup.Label>
      <div>
        {OPTIONS.map((option) => {
          return (
            <RadioGroup.Option key={option.name} value={option}>
              {({ checked }) => (
                <>
                  <div className={styles.checkboxContainer}>
                    {checked ? (
                      <div>
                        <div className={`${styles.square} ${checked && styles.squareChecked}`}></div>
                      </div>
                    ) : (
                      <div className={styles.square}></div>
                    )}
                    <RadioGroup.Label as="p">{option.name}</RadioGroup.Label>
                  </div>
                </>
              )}
            </RadioGroup.Option>
          );
        })}
      </div>
    </RadioGroup>
  );
}
