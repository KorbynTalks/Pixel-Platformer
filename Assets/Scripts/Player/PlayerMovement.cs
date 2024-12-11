using UnityEngine.Rendering.PostProcessing;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public Animator animator;
    public ParticleSystem deathParticles;
    public AudioSource deathAudioSource;
    public AudioSource bgMusic;
    public SelectorManager selectorManager;
    [SerializeField] private PostProcessProfile postProcessProfile;
    private Vignette vignette;
    public float vignetteSpeed;
    [SerializeField] private float jumpingPower = 16f;
    public AudioSource jumpAudioSource;
    private bool isFacingRight = true;
    private bool gameOver = false;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private void Start()
    {
        postProcessProfile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("WantedPlayer") == 0)
        {
            MainPlayer("Speed", "Idle", "JumpFall", "IsJumping", 0);
        }
    }

    private void FixedUpdate()
    {
        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            jumpAudioSource.Play();
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Death();
        }
    }

    void Death()
    {
        deathParticles.Play();
        deathAudioSource.Play();
        bgMusic.Stop();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
        speed = 0f;
        rb.simulated = false;
        vignette.enabled.value = true;
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.47f, vignetteSpeed * Time.deltaTime);
        gameOver = true;
        Invoke("Restart", 1f);
    }

    void Restart()
    {
        int loadedScene;
        loadedScene = SceneManager.GetActiveScene().buildIndex;
        vignette.intensity.value = 0f;
        vignette.enabled.value = false;

        SceneManager.LoadScene(loadedScene);
    }

    void MainPlayer(string speedAnimString, string whatToPlayForIdle, string whatToPlayForJumpFall, string booleanNameforIsJumping, int whatCharacter)
    {
        animator.SetInteger("SelectedCharacter", whatCharacter);

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat(speedAnimString, Mathf.Abs(horizontal)); // activates the walk animation when moving
        if (Input.GetButtonUp("Horizontal") && !gameOver) // this disables the walk animation when no longer holding the arrow keys/WASD keys.
        {
            animator.Play(whatToPlayForIdle);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() && !gameOver)
        {
            jumpAudioSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && !gameOver)
        {
            animator.Play(whatToPlayForJumpFall, -1, 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
        animator.SetBool(booleanNameforIsJumping, !IsGrounded() && rb.velocity.y != 0f); // activates the jumping animation
    }
}