using UnityEngine;

[CreateAssetMenu(menuName = "Potato/Var/Fader")]
public class RuntimeFader : ScriptableObject
{
	[SerializeField] private float duration = 1.5f;
	[SerializeField] private float startValue = 0f;
	private float value;
	private float target;

	public float Duration => duration;
	public float Value => value;

	private void OnEnable()
		=> value = startValue;

	public void Darken()
		=> target = 0f;

	public void Brighten()
		=> target = 1f;

	public void Update()
		=> value = Mathf.MoveTowards(value, target, 1/ Mathf.Max(duration, 0.01f) * Time.deltaTime);
}
