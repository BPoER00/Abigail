import ListBox from "components/ListBox";
import { NAV_BAR_OPTIONS } from "constants/NAV_BAR_OPTIONS";
import Link from "next/link";

import styles from "./styles.module.css";

export default function ItemMenu({ currentPage = false }) {
  return (
    <>
      {NAV_BAR_OPTIONS.map(({ id, icon, rightIcon, title, path = "", subModules = [], root }) => {
        return (
          <li className={`${styles.item} ${root === currentPage && styles.currentItem}`} key={id}>
            {subModules.length > 0 ? (
              <ListBox
                currentPage={currentPage}
                data={subModules}
                placeholder={title}
                leftIcon={icon()}
                rightIcon={rightIcon()}
              />
            ) : (
              <Link href={path}>
                <a className={styles.element}>
                  {typeof icon === "function" && icon()}
                  <span className={styles.link}>{title}</span>
                </a>
              </Link>
            )}
          </li>
        );
      })}
    </>
  );
}
