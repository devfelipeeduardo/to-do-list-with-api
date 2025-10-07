import { useState } from "react";
import "./Checkbox.css";

function Checkbox() {
  const [checked, setChecked] = useState(false);

  return (
    <label className="checkbox-container">
      <input
        type="checkbox"
        checked={checked}
        onChange={(e) => setChecked(e.target.checked)}
      />
      <span className="checkmark"></span>
    </label>
  );
}

export default Checkbox;
