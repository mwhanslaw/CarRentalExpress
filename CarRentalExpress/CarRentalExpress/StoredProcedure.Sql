//Written by : Martyn Whanslaw


SET SERVEROUTPUT ON SIZE 4000

DROP PROCEDURE RESERVE_VEHICLE;

CREATE OR REPLACE PROCEDURE RESERVE_VEHICLE
(
	pmodel VARCHAR2,
	psuccess OUT NUMBER
)
IS
	pcount INTEGER;
BEGIN
	SELECT COUNT(*) INTO pcount FROM rental_car WHERE vehicle_model = pmodel; 
	IF pcount = 0 THEN 
		psuccess := 0;
	ELSE				
		UPDATE rental_car SET customer_id = USER WHERE vehicle_model = pmodel AND customer_id IS NULL AND ROWNUM <=1;
		psuccess := 1;
	END IF;
END;
/
SHOW ERRORS