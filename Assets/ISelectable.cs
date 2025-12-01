using UnityEngine;

public interface ISelectable
{
  bool Selected { get; set; }
  void Select(Material material);
  
}