var rotspeed : float = 0.05;
function Update () {
transform.Rotate(Vector3.up * Time.deltaTime*rotspeed, Space.World);
}