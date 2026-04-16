select * from tbl_MaterialHistory
select * from tbl_Materialsusedformanufacturing
select * from tbl_machinelogdetails
select * from tbl_PurchaseDetails
select * from tbl_billingDetails
select * from tbl_billingDetailswithoutgst

truncate table tbl_MaterialHistory

--don't truncate raw material and stock table 
select * from tbl_RawMaterial
select * from tbl_stockdetails
update tbl_StockDetails set CurrentStocks=0 where MaterialId in (7,8,9)
delete from tbl_StockDetails where MaterialId not in (7,8,9)
delete from tbl_rawmaterial  where id not in (7,8,9)