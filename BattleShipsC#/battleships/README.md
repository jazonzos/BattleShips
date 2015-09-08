
// @TOM
// Get User detail dialog
  function getAuthorityTemplateDialog()
  {            
      // shorthand alias
      var fm = Ext.form;    
      var fieldWidth = 300;
      var fieldSetWidth = 200;
      var fieldSetHeight = 530; // 470; // 380;
      //var fieldSetHeightHalf1 = 180;
      var fieldSetHeightHalf = 265;// 210;
      var store_Databases = getStore_Databases();
      
      var panel = new Ext.Panel({
                region : 'center',
                layout : 'absolute',      
                plain : true,
                baseCls : 'x-plain',        
                layoutConfig: {                
                    extraCls: 'x-abs-layout-item'
                },               
                items : [
                        {
                            xtype : 'fieldset',
                            title : 'General section',
                            id : 'fs_AS_TEMP_General',
                            disabled : false,                              
                            x : 10,
                            y : 20,
                            width : fieldSetWidth,            
                            height : fieldSetHeightHalf, //1,
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Admin Section',
                                  id : 'chk_AS_TEMP_'+AU_AdminSection,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          //var Ext.getCmp('frm_AS_TEMP_RequisitionHistory').findField('');
                                          if (p_checked){
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Settings).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_AddressBook).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_BusinessDepartment).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_StockCategory).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_UnitOfMeasurement).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Report).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Settings).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_AddressBook).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_BusinessDepartment).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_StockCategory).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_UnitOfMeasurement).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Report).enable();
                                            if (!Global_Authority_PendingForUpdate) {
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Settings).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_AddressBook).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_BusinessDepartment).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_StockCategory).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_UnitOfMeasurement).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Report).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Settings).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_AddressBook).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_BusinessDepartment).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_StockCategory).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_UnitOfMeasurement).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Report).setValue(false);
                                            }
                                          }
                                          else {
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Settings).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_AddressBook).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_BusinessDepartment).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_StockCategory).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_UnitOfMeasurement).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Admin_Report).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Settings).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_AddressBook).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_BusinessDepartment).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_StockCategory).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_UnitOfMeasurement).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Admin_Report).disable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Stock Section',
                                  id : 'chk_AS_TEMP_'+AU_StockSection,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          //var Ext.getCmp('frm_AS_TEMP_RequisitionHistory').findField('');
                                          if (p_checked){
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Requisition).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Invoice).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_StockMaintenance).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Stocktake).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Order).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Report).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Requisition).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Invoice).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_StockMaintenance).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_ALLOW_MODIFY_PRICE_WHEN_READ_ONLY).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Stocktake).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Order).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_READONLY_STOCK_RECEIVING_ORDER).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Report).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_REQUIREAPPROVALPERMISSION).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_ALLOWSTOCKALLOCATION).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_NOT_ALLOW_MODIFY_LOCK_IN_PRICING).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_NEW_PDF_INVOICE_ITEM_ADDED).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.AU_STOCK_CUSTOMER_ORDER).enable();
                                            if (!Global_Authority_PendingForUpdate) {
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Requisition).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Invoice).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_StockMaintenance).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Stocktake).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Order).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Report).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Requisition).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Invoice).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_StockMaintenance).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_ALLOW_MODIFY_PRICE_WHEN_READ_ONLY).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Stocktake).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Order).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_READONLY_STOCK_RECEIVING_ORDER).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Report).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_REQUIREAPPROVALPERMISSION).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_ALLOWSTOCKALLOCATION).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_NOT_ALLOW_MODIFY_LOCK_IN_PRICING).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_NEW_PDF_INVOICE_ITEM_ADDED).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.AU_STOCK_CUSTOMER_ORDER).enable();
                                            }                                                          
                                          }
                                          else {
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Requisition).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Invoice).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_StockMaintenance).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Stocktake).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Order).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Stock_Report).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Requisition).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Invoice).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_StockMaintenance).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_ALLOW_MODIFY_PRICE_WHEN_READ_ONLY).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Stocktake).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Order).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_READONLY_STOCK_RECEIVING_ORDER).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Stock_Report).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_REQUIREAPPROVALPERMISSION).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_ALLOWSTOCKALLOCATION).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.STOCK_NOT_ALLOW_MODIFY_LOCK_IN_PRICING).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_NEW_PDF_INVOICE_ITEM_ADDED).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.AU_STOCK_CUSTOMER_ORDER).enable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Pantry Section',
                                  id : 'chk_AS_TEMP_'+AU_PantrySection,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          //var Ext.getCmp('frm_AS_TEMP_RequisitionHistory').findField('');
                                          if (p_checked){
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeOrder).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeBook).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Report).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Tafe).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeOrder).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeBook).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Report).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Tafe).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.PANTRY_RECIPEBOOK_REQUIREAPPROVALPERMISSION).enable();
                                            if (!Global_Authority_PendingForUpdate) {
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeOrder).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeBook).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Report).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Tafe).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeOrder).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeBook).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Report).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Tafe).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.PANTRY_RECIPEBOOK_REQUIREAPPROVALPERMISSION).setValue(false);
                                            }
                                          }
                                          else {
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeOrder).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_RecipeBook).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Report).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Pantry_Tafe).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeOrder).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeBook).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Report).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Pantry_Tafe).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.PANTRY_RECIPEBOOK_REQUIREAPPROVALPERMISSION).disable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Revenue Section',
                                  id : 'chk_AS_TEMP_'+AU_RevenueSection,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          //var Ext.getCmp('frm_AS_TEMP_RequisitionHistory').findField('');
                                          if (p_checked){
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenRevenue).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenReport).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenRevenue).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenReport).enable();
                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_WASTAGE_RECORD_WARNING).enable();
                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_SALEDATA_NOTIFICATION).enable();
                            Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.MISSING_SALEDATA_NOTIFICATION).enable();
                            
                                            if (!Global_Authority_PendingForUpdate) {
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenRevenue).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenReport).setValue(true);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenRevenue).setValue(false);
                                                Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenReport).setValue(false);
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_WASTAGE_RECORD_WARNING).setValue(true);
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_SALEDATA_NOTIFICATION).setValue(true);
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.MISSING_SALEDATA_NOTIFICATION).setValue(true);
                                            }
                                          }
                                          else {
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenRevenue).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_Revenue_KitchenReport).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenRevenue).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenReport).disable();
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_WASTAGE_RECORD_WARNING).disable();
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.RECEIVE_SALEDATA_NOTIFICATION).disable();
                          Ext.getCmp('chk_AS_TEMP_'+AUTHORITY.MISSING_SALEDATA_NOTIFICATION).disable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Menu Builder Section',
                                  id : 'chk_AS_TEMP_'+ AU_MenuBuilder_Section,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          if (p_checked){
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_MenuBuilder_Menu).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_MenuBuilder_Special).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Menu).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Special).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_MENU_REQUIREAPPROVALPERMISSION).enable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_SPECIAL_REQUIREAPPROVALPERMISSION).enable();
                                          }
                                          else {
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_MenuBuilder_Menu).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_MenuBuilder_Special).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Menu).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Special).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_MENU_REQUIREAPPROVALPERMISSION).disable();
                                            Ext.getCmp('chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_SPECIAL_REQUIREAPPROVALPERMISSION).disable();
                                          }
                                      }
                                  }
                                }
                            ]
                        }, // End General section
                        {
                            xtype : 'fieldset',
                            title : 'Admin section',
                            id : 'fs_AS_TEMP_Admin',
                            disabled : false,                     
                            x : 220,
                            y : 20,
                            width : fieldSetWidth,            
                            height : fieldSetHeight,                  
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Settings',
                                  id : 'chk_AS_TEMP_'+AU_Admin_Settings
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_Settings
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Address Book',
                                  id : 'chk_AS_TEMP_'+AU_Admin_AddressBook
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_AddressBook
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Business Department',
                                  id : 'chk_AS_TEMP_'+AU_Admin_BusinessDepartment
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_BusinessDepartment
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Stock Category',
                                  id : 'chk_AS_TEMP_'+AU_Admin_StockCategory
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_StockCategory
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Unit Of Measurement',
                                  id : 'chk_AS_TEMP_'+AU_Admin_UnitOfMeasurement
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_UnitOfMeasurement
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Report',
                                  id : 'chk_AS_TEMP_'+AU_Admin_Report
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Admin_Report
                                }
                            ]
                        }, // End admin section
                        {
                            xtype : 'fieldset',
                            title : 'Stock section',
                            id : 'fs_AS_TEMP_Stock',
                            disabled : false,
                            x : 430,
                            y : 20,
                            width : fieldSetWidth,            
                            height : fieldSetHeight,                               
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Requisition',
                                  id : 'chk_AS_TEMP_'+AU_Stock_Requisition
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_Requisition
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Invoice',
                                  id : 'chk_AS_TEMP_'+AU_Stock_Invoice
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_Invoice
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Stock Maintenance',
                                  id : 'chk_AS_TEMP_'+AU_Stock_StockMaintenance
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_StockMaintenance
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Allow change stock\'s price in read-only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AUTHORITY.STOCK_ALLOW_MODIFY_PRICE_WHEN_READ_ONLY
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Require approval',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_REQUIREAPPROVALPERMISSION
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Allow stock allocation',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AUTHORITY.STOCK_STOCKMAINTENANCE_ALLOWSTOCKALLOCATION
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'NOT Allow to change locked-in price',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AUTHORITY.STOCK_NOT_ALLOW_MODIFY_LOCK_IN_PRICING
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Stocktake',
                                  id : 'chk_AS_TEMP_'+AU_Stock_Stocktake
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_Stocktake
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Order',
                                  id : 'chk_AS_TEMP_'+AU_Stock_Order
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_Order
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only receiving order',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS'+ AU_READONLY_STOCK_RECEIVING_ORDER
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Report',
                                  id : 'chk_AS_TEMP_'+AU_Stock_Report
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Stock_Report
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'New stock items added notification',
                                  id : 'chk_AS_TEMP_'+ AUTHORITY.RECEIVE_NEW_PDF_INVOICE_ITEM_ADDED
                                },
                                {
                                    xtype: 'checkbox',
                                    hideLabel: true,
                                    boxLabel: 'Access Customer Order',
                                    id: 'chk_AS_TEMP_' + AUTHORITY.AU_STOCK_CUSTOMER_ORDER
                                }
                            ]
                        }, // End stock section                                                      
                        {
                            xtype : 'fieldset',
                            title : 'Pantry section',
                            id : 'fs_AS_TEMP_Pantry',
                            disabled : false,
                            x : 640,
                            y : 20,
                            width : fieldSetWidth,
                            height : fieldSetHeight,                                
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Recipe Order',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_RecipeOrder
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeOrder
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Recipe Book',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_RecipeBook
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Pantry_RecipeBook
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Require approval',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AUTHORITY.PANTRY_RECIPEBOOK_REQUIREAPPROVALPERMISSION
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access TAFE',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_Tafe
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Pantry_Tafe
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Report',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_Report
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Pantry_Report
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Personal Recipe Book',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_PersonalRecipeBook
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Limit Recipes in PRB',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_PersonalRecipeBook_Limit,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          if (p_checked){
                                              Ext.getCmp('numVal_AS_TEMP_'+AU_Pantry_PersonalRecipeBook_Limit).enable();
                                          }
                                          else {
                                              Ext.getCmp('numVal_AS_TEMP_'+AU_Pantry_PersonalRecipeBook_Limit).disable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'numberfield',
                                  fieldLabel : 'Number limit',
                                  width : 50,
                                  value : 10,
                                  disabled : true,
                                  id : 'numVal_AS_TEMP_'+AU_Pantry_PersonalRecipeBook_Limit
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Clean PRB when log in',
                                  id : 'chk_AS_TEMP_'+AU_Pantry_PersonalRecipeBook_CleanAfterLogin
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read Only Media Manager',
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_MediaManager
                                }
                            ]
                        }, // End pantry section
                        {
                            xtype : 'fieldset',
                            title : 'Revenue section',
                            id : 'fs_AS_TEMP_Revenue',
                            disabled : false,                              
                            x : 850,
                            y : 20,
                            width : fieldSetWidth,            
                            height : fieldSetHeightHalf,  
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Kitchen Revenue',
                                  id : 'chk_AS_TEMP_'+AU_Revenue_KitchenRevenue
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenRevenue
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Report',
                                  id : 'chk_AS_TEMP_'+AU_Revenue_KitchenReport
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_Revenue_KitchenReport
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Receive wastage record warning',
                                  id : 'chk_AS_TEMP_'+AUTHORITY.RECEIVE_WASTAGE_RECORD_WARNING
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Receive sale data notification',
                                  id : 'chk_AS_TEMP_'+ AUTHORITY.RECEIVE_SALEDATA_NOTIFICATION
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Missing sale data notification',
                                  id : 'chk_AS_TEMP_'+ AUTHORITY.MISSING_SALEDATA_NOTIFICATION
                                }
                            ]
                        }, // End Revenue section
                        {
                            xtype : 'fieldset',
                            title : 'License section',
                            id : 'fs_AS_TEMP_License',
                            disabled : false,
                            x : 10,
                            y : fieldSetHeightHalf + 30,
                            width : fieldSetWidth,
                            height : fieldSetHeightHalf - 10,     
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Databases Section',
                                  id : 'chk_AS_TEMP_'+AU_DatabaseSection
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_DatabaseSection
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Users section',
                                  id : 'chk_AS_TEMP_'+AU_UserSection
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+AU_ReadOnly_UserSection
                                }
                            ]
                        }, // End License section 
                        {
                            xtype : 'fieldset',
                            title : 'Advance Security',
                            id : 'fs_AS_TEMP_AdvanceSecurity',
                            disabled : false,
                            x : 850,
                            //y : 245,
                            //width : fieldSetWidth,            
                            //height : fieldSetHeightHalf,
                            y : fieldSetHeightHalf + 30,
                            width : fieldSetWidth,
                            height : fieldSetHeightHalf - 10,  
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Error Log',
                                  id : 'chk_AS_TEMP_' + AU_ERRORLOG_ADMIN
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Dashboard',
                                  id : 'chk_AS_TEMP_' + AU_DASHBOARD_SECTION
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Advance Security',
                                  id : 'chk_AS_TEMP_' + AU_AdvanceSecuritySection
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Futura Section',
                                  id : 'chk_AS_TEMP_' + AU_FuturaSection
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Advertisement Section',
                                  id : 'chk_AS_TEMP_' + AU_AdvertisementSection
                                },{
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Database Jumper',
                                  id : 'chk_AS_TEMP_'+AU_Database_Jumper,
                                  listeners : {
                                      check : function(p_checkbox, p_checked){
                                          if (p_checked){
                                              Ext.getCmp('textVal_AS_TEMP_'+AU_Database_Jumper).enable();
                                          }
                                          else {
                                              Ext.getCmp('textVal_AS_TEMP_'+AU_Database_Jumper).disable();
                                          }
                                      }
                                  }
                                },
                                {
                                  xtype : 'combo',
                                  //fieldLabel : 'Stand database',
                                  hideLabel : true,
                                  width : 175,
                                  //value : 10,
                                  disabled : true,
                                  id : 'textVal_AS_TEMP_' + AU_Database_Jumper,
                                  store: store_Databases,
                    displayField: 'description',
                    valueField: 'databaseName',
                    typeAhead: true,
                    triggerAction: 'all',
                    minChars: 1,
                    lazyRender: true,
                    editable: true,
                    forceSelection: true,
                    emptyText: 'Select main database...',
                    //style: { fontSize: '11px' },
                    mode : 'remote',
                    listeners : {
                      beforequery: function(qe){
                          delete qe.combo.lastQuery; // Reload every click
                      },
                      beforeselect : function( p_combo, p_record, p_index ){
                        
                      }
                    }
                                }
                            ]
                        }, // End Advance security section
                        
                        //Menu Builder section
                        {
                            xtype : 'fieldset',
                            title : 'Menu Builder section',
                            id : 'fs_AS_TEMP_MenuBuilder',
                            disabled : false,                              
                            x : 1060,
                            y : 20,
                            width : fieldSetWidth,            
                            height : fieldSetHeight,  
                            collapsible : true,
                            items : [
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Menu Builder',
                                  id : 'chk_AS_TEMP_'+ AU_MenuBuilder_Menu
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Menu
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Require approval',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_MENU_REQUIREAPPROVALPERMISSION
                                },                                  
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Access Special Menu',
                                  id : 'chk_AS_TEMP_'+ AU_MenuBuilder_Special
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Read only',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+ AU_ReadOnly_MenuBuilder_Special
                                },
                                {
                                  xtype : 'checkbox',
                                  hideLabel : true,
                                  boxLabel : 'Require approval',
                                  style: {
                          marginLeft: '30px'
                      },
                                  id : 'chk_AS_TEMP_'+ AUTHORITY.MENUBUILDER_SPECIAL_REQUIREAPPROVALPERMISSION
                                },  
                                
                            ]
                        }, // End Menu Builder section                       
                ]
        });

      /****************************/
      /* Employee detail window    */
      /****************************/
      var dialog = new Ext.Window({
          title: 'User authorities',
          layout: 'border',
          closeAction: 'hide',
          iconCls : 'icon-stock',
          expandOnShow : true,
          closable: true,
          resizable: true,
          modal: true, 
          plain: true,
          minimizable : true,
          maximizable : true,
          monitorResize : true,
          defaults: {
              split: true,
              animFloat: false,
              autoHide: false,
              useSplitTips: true
          },
          buttons : [
            {
              xtype : 'button',
              text : 'Confirm',
              id : 'btn_AS_TEMP_UserAuthorities_Save',
              iconCls : 'icon-save-large', scale : 'large',
              handler : function(){
                  var selectedUserAuthorities = new Array();
                  var j = 0;
                  for (var i = 1; i<=AU_NumOfConstants; i++)
                  {
                    try{
                        if (Ext.getCmp('chk_AS_TEMP_'+i).checked && !Ext.getCmp('chk_AS_TEMP_'+i).disabled)
                        {
                            var numberValue = 0;
                            var textValue = '';
                            if (Ext.getCmp('numVal_AS_TEMP_' + i) != null){
                                numberValue = Ext.getCmp('numVal_AS_TEMP_' + i).getValue();
                            }
                            if (Ext.getCmp('textVal_AS_TEMP_' + i) != null){
                                textValue = Ext.getCmp('textVal_AS_TEMP_' + i).getValue();
                            }
                          
                            selectedUserAuthorities[j] = {
                                authorityId : i,
                                numberValue : numberValue,
                                textValue : textValue
                            };
                            j++;
                        }
                    }catch(e){}
                  }
                  // Wrap the list to an object
                  var jsonWrapperObject = {listOfUserAuthorities : selectedUserAuthorities};
                
                  Ext.Ajax.request({
                          method: 'POST',
                          url: '/User/ModifyUserAuthoritiesInAdvanceSecurity',
                          params:
                          {                           
                              userId : Global_SelectedUserId,
                              listOfUserAuthorities : Ext.util.JSON.encode(jsonWrapperObject)
                          },
                          success : function(result, request) {
                              loadMask.hide();                                            
                              var jsonData = Ext.util.JSON.decode(result.responseText);                                                        
                              if (jsonData.IsSuccess)
              {
                showSuccessNotification(jsonData.Info, NOTIFICATION.ICON_INFORMATION);
                                  grid_User.getStore().reload();
                                  dialog.hide();    
                              }
                              else {                                
                                  showErrorMessageWithEmailNotify(jsonData.Info);
                              }
                                                              
                          },
                          failure : function(result, request) {                                                        
                              loadMask.hide();
                              dialog.hide();
                          }
                  }); // End ajax   
              } // End save handler button
            },
            {
              xtype : 'button',
              text : 'Cancel',
              iconCls: 'icon-cancel-large', scale: 'large',
              scale : 'large',
              handler : function(){
                  dialog.hide();
              }
            }
          ],
          items : [panel],
          listeners : {
              'afterrender' : function(){               
                  
              },
              'beforehide' : function(p_This){
                          
              },
              'beforeshow' : function(p_This){                                        
                  // Fit this window to the client browser screen with 90%
                  fitWindowDimension(p_This, 1290, 630);
                  // Initialize
                  for(var i = 1;i<=AU_NumOfConstants;i++)
                  {
                    try{
                      Ext.getCmp('chk_AS_TEMP_' + i).setValue(false);
                      if (i > 4 && i!=AU_DatabaseSection && i!=AU_UserSection && i!=AU_AdvanceSecuritySection && i!=AU_FuturaSection && i!=AU_AdvertisementSection
                            && i!=AU_ERRORLOG_ADMIN && i != AU_DASHBOARD_SECTION
                            && i!=AU_Pantry_PersonalRecipeBook && i!=AU_Pantry_PersonalRecipeBook_Limit && i!=AU_ReadOnly_MediaManager
                            && i!=AU_Pantry_PersonalRecipeBook_CleanAfterLogin && i!=AU_Database_Jumper
                  && i!=AUTHORITY.RECEIVE_WASTAGE_RECORD_WARNING
                  && i!=AUTHORITY.RECEIVE_SALEDATA_NOTIFICATION
                  && i!=AUTHORITY.MISSING_SALEDATA_NOTIFICATION
                  && i!=AUTHORITY.RECEIVE_NEW_PDF_INVOICE_ITEM_ADDED
                  && i!=AUTHORITY.AU_STOCK_CUSTOMER_ORDER
                  && i!= AU_MenuBuilder_Section){ // Disable sub section checkbox
                          Ext.getCmp('chk_AS_TEMP_' + i).disable();
                      }
                      if (Ext.getCmp('numVal_AS_TEMP_' + i) != null) Ext.getCmp('numVal_AS_TEMP_' + i).setValue(10);
                      if (Ext.getCmp('textVal_AS_TEMP_' + i) != null) Ext.getCmp('textVal_AS_TEMP_' + i).setValue('');
                    }catch(e){}
                  }
                  Ext.getCmp('chk_AS_TEMP_' + AU_ReadOnly_DatabaseSection).enable();
                  Ext.getCmp('chk_AS_TEMP_' + AU_ReadOnly_UserSection).enable();
                  
                  // Update data
                  if (Global_SelectedUserId != -1){
                      var userAuthorities = grid_User.getStore().getById(Global_SelectedUserId).data.userAuthorities;
                      
                      
                      Global_Authority_PendingForUpdate = true;
                      for(var i = 0;i<userAuthorities.length;i++)
                      {
                        try{
                            var authorityId = userAuthorities[i].authorityId;
                            var numberValue = userAuthorities[i].numberValue;
                            var textValue = userAuthorities[i].textValue;
                            
                            Ext.getCmp('chk_AS_TEMP_' + authorityId).setValue(true);
                            if (Ext.getCmp('numVal_AS_TEMP_' + authorityId) != null) Ext.getCmp('numVal_AS_TEMP_' + authorityId).setValue(numberValue);
                            if (Ext.getCmp('textVal_AS_TEMP_' + authorityId) != null) Ext.getCmp('textVal_AS_TEMP_' + authorityId).setValue(textValue);
                        }catch(e){}
                      }
                      Global_Authority_PendingForUpdate = false;
                  }
                  store_Databases.baseParams = {supplierId : -1, start : 0, limit : 1000, userId : Global_SelectedUserId};                   
              },
              'show' : function(p_This){                
                  if (Global_SelectedUserId != -1){
                      
                  } 
                  else {                  
                                                              
                  }                
                  //p_This.getEl().fadeIn(); 
              }
          }
      });   
  
      return dialog;
  }
    
    // Return databases' store
    function getStore_Databases(){
    	var store = new Ext.data.JsonStore({
	        baseParams : {supplierId: -1, start : 0, limit : 1000},
	        proxy: new Ext.data.HttpProxy({
	            url: '/Database/SearchAllDatabases',
	            dataType: 'json',
	            method: 'POST'
	        }),
	        autoLoad : false,
            fields: Ext.data.Record.create([
		        { name: 'databaseId', type: 'number' },
		        { name: 'databaseName', type: 'string' },
		        { name: 'description', type: 'string' },
		        { name: 'companyName', type: 'string' },
		        { name: 'registrationId', type: 'number' },
		        { name: 'serialNumber', type: 'number' },
		        { name: 'version', type: 'string' },
		        { name: 'expiryDate', type: 'date' },
		        { name: 'isActive', type: 'boolean' }
		    ]),
            root: 'data',
            idProperty: 'databaseId',
            totalProperty : 'totalCount',
	        listeners : {
	        	'beforeload' : function(){        		
	        	},
	            'load' : function(){                
	            },
	            'loadexception' : function(){
		      		showStoreLoadingErrorMessage(store);
		        }
	        }
	    });
	    return store;
    }
    
    // This function save the changes to the employee grid
    function SaveCurrentUser(){            
              loadMask.msg = "Please wait !";
              var isRemoved = false;
              
              var userEmail         = Ext.getCmp('txt_AS_TEMP_UserDetail_Email').getValue();
              var userPassword      = Ext.getCmp('txt_AS_TEMP_UserDetail_Password').getValue();
              var firstname         = Ext.getCmp('txt_AS_TEMP_UserDetail_Firstname').getValue();
              var lastname          = Ext.getCmp('txt_AS_TEMP_UserDetail_Lastname').getValue();
              var phoneNo           = Ext.getCmp('txt_AS_TEMP_UserDetail_PhoneNo').getValue();
              var inUseDatabase     = Ext.getCmp('cmb_AS_TEMP_UserDetail_ActiveDatabase').getValue();
                                            
              var User = {
                  userId : Global_SelectedUserId,
                  userEmail : userEmail,                                                                               
                  userPassword : userPassword,
                  firstname : firstname,
                  lastname : lastname,
                  phoneNo : phoneNo,
                  inUseDatabase : inUseDatabase
              };
                                                                              
              var userJsonData = Ext.util.JSON.encode(User);
              loadMask.show();
              // Sending ajax request
              Ext.Ajax.request({
                    method: "POST",
                    url: '/User/SaveUser',
                    params:
                    {
                        userData : userJsonData
                    },
                    success : function(result, request) {
                        loadMask.hide();
                        var jsonData = Ext.util.JSON.decode(result.responseText);                                                        
                        if (jsonData.IsSuccess)
						{
							showSuccessNotification(jsonData.Info, NOTIFICATION.ICON_INFORMATION);
                            grid_User.getStore().reload();
                            UserDetailDialog.hide();
                        }
                        else {                                
                            showErrorMessageWithEmailNotify(jsonData.Info);
                        }
                    },
                    failure : function(result, request) {                                                        
                        loadMask.hide();
                    }
              }); // End ajax 
                          
              UserDetailDialog.hide();                                          
    } // End save role
    
    // Declare a create new database dialog
    var dlg_SelectCompanyRegistration = new Ext.CTBSelectRegistrationWindow({});
    // This function will show a form to let user create a new database for an exist company or a new company
    function createNewDatabase(){
    	dlg_SelectCompanyRegistration.show();
    }
}); // End Ext.Ready
