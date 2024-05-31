import { React, useEffect, useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication.js";
import { getBanner } from "../../../services/bannerService.js";
import { FaEdit } from "react-icons/fa";
import EditBannerForm from "./components/EditBannerForm/index.js";

export default function BannersAdmin() {
  const [banner, setBanner] = useState({});
  const [viewEditForm, setViewEditForm] = useState(false);
  const { authenticated } = useAuthentication();

  useEffect(() => {
    async function fetchBanner() {
      const bannerData = await getBanner();
      setBanner(bannerData);
    }
    fetchBanner();
  }, []);

  return (
    authenticated && (
      <div>
        <div>
          <h1>Banner</h1>
          {!viewEditForm ? (
            <>
              <img
                src={`data:image/png;base64,${banner.image}`}
                alt="banner"
                // style={{ width: "100px" }}
                className={styles.banneradmin}
              />
              <div
              onClick={() => setViewEditForm(true)}
              style={{ cursor: "pointer" }}
              >
              
              <FaEdit/>
              
              </div>
            </>
          ) : (
            <EditBannerForm setViewEditForm={setViewEditForm} />
          )}
        </div>
      </div>
    )
  );
}
