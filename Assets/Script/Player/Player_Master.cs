using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour {

	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventInventoryChange;
	public event GeneralEventHandler EventHandesEmpty;

	public event GeneralEventHandler EventAmmoChange;
    

	public delegate void AmmoPickUpEventHandler(string ammoName,int quality);
	public  event AmmoPickUpEventHandler EventPickUpAmmo;

	public delegate void PlayerHealthEventHandler(int healthChange);
	public event PlayerHealthEventHandler EventPlayerHealthIncrease;
	public event PlayerHealthEventHandler EventPlayerHealthDeduction;


	public void CallEventInventoryChange(){
	
		if (EventInventoryChange != null) {
			EventInventoryChange ();
		}
	}

	public void CallEventHandsEmpty(){

		if (EventHandesEmpty!= null) {
			EventHandesEmpty ();
		
		}
	}
	public void CallEventAmmoChange(){
		if (EventAmmoChange != null) {
			EventAmmoChange ();
		}
	
	}

	public void CallEventPickUpAmmo(string ammoName,int quality){
	
		if (EventPickUpAmmo != null) {
		
			EventPickUpAmmo (ammoName, quality);
		}
	}


	public void CallEventPlayerHealthDeduction(int damage){
	
		if (EventPlayerHealthDeduction != null) {
		
			EventPlayerHealthDeduction (damage);

		}
	}
	public void CallEventPlayerHealthIncrease(int increase){
	
		if (EventPlayerHealthIncrease != null) {
		
			EventPlayerHealthIncrease (increase);
		}
	}
}
