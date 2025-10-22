/**
 * STRANDVENTURE Login Pages JavaScript
 * Enhanced functionality for Teacher and Student login pages
 */

// Document ready function
$(document).ready(function() {
    initializeLoginPage();
});

// Initialize login page functionality
function initializeLoginPage() {
    initializeLRNFormatting();
    initializeFormValidation();
    initializeLoginForm();
    setupAccessibilityFeatures();
    setupKeyboardNavigation();
}

// Password toggle functionality
function togglePassword(inputId) {
    const passwordInput = document.getElementById(inputId);
    const toggleIcon = document.getElementById(inputId + '_icon');
    
    if (passwordInput && toggleIcon) {
        if (passwordInput.type === 'password') {
            passwordInput.type = 'text';
            toggleIcon.classList.remove('fa-eye');
            toggleIcon.classList.add('fa-eye-slash');
            toggleIcon.parentElement.setAttribute('aria-label', 'Hide password');
        } else {
            passwordInput.type = 'password';
            toggleIcon.classList.remove('fa-eye-slash');
            toggleIcon.classList.add('fa-eye');
            toggleIcon.parentElement.setAttribute('aria-label', 'Show password');
        }
    }
}

// CAPTCHA refresh functionality
function refreshCaptcha() {
    const captchaImage = document.getElementById('captchaImage');
    const refreshButton = document.querySelector('.captcha-refresh');
    
    if (captchaImage && refreshButton) {
        // Show loading state
        refreshButton.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
        refreshButton.disabled = true;
        
        // Determine which page we're on
        const isTeacherPage = window.location.pathname.toLowerCase().includes('teacher');
        const endpoint = isTeacherPage ? '/Home/RefreshTeacherCaptcha?handler=RefreshCaptcha' : '/Home/RefreshStudentCaptcha?handler=RefreshCaptcha';
        
        // Make AJAX request to refresh CAPTCHA
        $.ajax({
            url: endpoint,
            type: 'POST',
            headers: {
                'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            },
            success: function(response) {
                if (response && response.image) {
                    captchaImage.src = 'data:image/svg+xml;base64,' + response.image;
                    
                    // Clear CAPTCHA input
                    const captchaInput = document.querySelector('input[name*="CaptchaInput"]');
                    if (captchaInput) {
                        captchaInput.value = '';
                        captchaInput.focus();
                    }
                    
                    // Show success feedback
                    showToast('CAPTCHA refreshed successfully', 'success');
                }
            },
            error: function() {
                showToast('Failed to refresh CAPTCHA. Please try again.', 'error');
            },
            complete: function() {
                // Restore button state
                refreshButton.innerHTML = '<i class="fas fa-sync-alt"></i>';
                refreshButton.disabled = false;
            }
        });
    }
}

// LRN input formatting
function initializeLRNFormatting() {
    const lrnInput = document.querySelector('input[name*="LRN"]');
    
    if (lrnInput) {
        lrnInput.addEventListener('input', function(e) {
            // Remove non-numeric characters
            let value = e.target.value.replace(/\D/g, '');
            
            // Limit to 12 digits
            if (value.length > 12) {
                value = value.substring(0, 12);
            }
            
            e.target.value = value;
            
            // Validate format and provide feedback
            validateLRN(value);
        });
        
        lrnInput.addEventListener('blur', function(e) {
            validateLRN(e.target.value);
        });
    }
}

// LRN validation
function validateLRN(value) {
    const lrnInput = document.querySelector('input[name*="LRN"]');
    const errorSpan = lrnInput ? lrnInput.parentElement.querySelector('.text-danger') : null;
    
    if (lrnInput && value.length > 0) {
        if (value.length !== 12) {
            lrnInput.classList.add('is-invalid');
            if (errorSpan) {
                errorSpan.textContent = 'LRN must be exactly 12 digits';
                errorSpan.style.display = 'block';
            }
            return false;
        } else {
            lrnInput.classList.remove('is-invalid');
            lrnInput.classList.add('is-valid');
            if (errorSpan) {
                errorSpan.style.display = 'none';
            }
            return true;
        }
    }
    return true;
}

// Form validation initialization
function initializeFormValidation() {
    // Real-time email validation
    const emailInput = document.querySelector('input[name*="Email"]');
    if (emailInput) {
        emailInput.addEventListener('blur', function(e) {
            validateEmail(e.target.value);
        });
    }
    
    // Real-time password validation
    const passwordInput = document.querySelector('input[name*="Password"]');
    if (passwordInput) {
        passwordInput.addEventListener('input', function(e) {
            validatePasswordStrength(e.target.value);
        });
    }
    
    // CAPTCHA input formatting
    const captchaInput = document.querySelector('input[name*="CaptchaInput"]');
    if (captchaInput) {
        captchaInput.addEventListener('input', function(e) {
            e.target.value = e.target.value.toUpperCase();
        });
    }
}

// Email validation
function validateEmail(email) {
    const emailInput = document.querySelector('input[name*="Email"]');
    const errorSpan = emailInput ? emailInput.parentElement.querySelector('.text-danger') : null;
    
    if (emailInput && email.length > 0) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            emailInput.classList.add('is-invalid');
            if (errorSpan) {
                errorSpan.textContent = 'Please enter a valid email address';
                errorSpan.style.display = 'block';
            }
            return false;
        } else {
            emailInput.classList.remove('is-invalid');
            emailInput.classList.add('is-valid');
            if (errorSpan) {
                errorSpan.style.display = 'none';
            }
            return true;
        }
    }
    return true;
}

// Password strength validation
function validatePasswordStrength(password) {
    const passwordInput = document.querySelector('input[name*="Password"]');
    
    if (passwordInput && password.length > 0) {
        let strength = 0;
        let feedback = [];
        
        // Check length
        if (password.length >= 8) strength++;
        else feedback.push('at least 8 characters');
        
        // Check for lowercase
        if (/[a-z]/.test(password)) strength++;
        else feedback.push('lowercase letter');
        
        // Check for uppercase
        if (/[A-Z]/.test(password)) strength++;
        else feedback.push('uppercase letter');
        
        // Check for numbers
        if (/\d/.test(password)) strength++;
        else feedback.push('number');
        
        // Check for special characters
        if (/[!@#$%^&*(),.?":{}|<>]/.test(password)) strength++;
        else feedback.push('special character');
        
        // Update UI based on strength
        if (strength >= 4) {
            passwordInput.classList.remove('is-invalid');
            passwordInput.classList.add('is-valid');
        } else if (strength >= 2) {
            passwordInput.classList.remove('is-invalid', 'is-valid');
        } else {
            passwordInput.classList.add('is-invalid');
        }
    }
}

// Login form submission
function initializeLoginForm() {
    const loginForm = document.querySelector('.login-form');
    const loginBtn = document.getElementById('loginBtn');
    
    if (loginForm && loginBtn) {
        loginForm.addEventListener('submit', function(e) {
            // Show loading state
            loginBtn.classList.add('loading');
            loginBtn.disabled = true;
            
            // Validate form before submission
            if (!validateFormBeforeSubmit()) {
                e.preventDefault();
                loginBtn.classList.remove('loading');
                loginBtn.disabled = false;
                return false;
            }
            
            // Form will submit normally
            return true;
        });
    }
}

// Form validation before submit
function validateFormBeforeSubmit() {
    let isValid = true;
    
    // Validate email (for teacher login)
    const emailInput = document.querySelector('input[name*="Email"]');
    if (emailInput && !validateEmail(emailInput.value)) {
        isValid = false;
    }
    
    // Validate LRN (for student login)
    const lrnInput = document.querySelector('input[name*="LRN"]');
    if (lrnInput && !validateLRN(lrnInput.value)) {
        isValid = false;
    }
    
    // Validate password
    const passwordInput = document.querySelector('input[name*="Password"]');
    if (passwordInput && passwordInput.value.length === 0) {
        passwordInput.classList.add('is-invalid');
        isValid = false;
    }
    
    // Validate CAPTCHA
    const captchaInput = document.querySelector('input[name*="CaptchaInput"]');
    if (captchaInput && captchaInput.value.length === 0) {
        captchaInput.classList.add('is-invalid');
        isValid = false;
    }
    
    if (!isValid) {
        showToast('Please correct the errors before submitting', 'error');
    }
    
    return isValid;
}

// Toast notification system
function showToast(message, type = 'info') {
    // Remove existing toasts
    const existingToasts = document.querySelectorAll('.toast-notification');
    existingToasts.forEach(toast => toast.remove());
    
    // Create toast element
    const toast = document.createElement('div');
    toast.className = `toast-notification toast-${type}`;
    toast.innerHTML = `
        <div class="toast-content">
            <i class="fas fa-${getToastIcon(type)}"></i>
            <span>${message}</span>
        </div>
    `;
    
    // Add styles
    toast.style.cssText = `
        position: fixed;
        top: 20px;
        right: 20px;
        background: ${getToastColor(type)};
        color: white;
        padding: 12px 20px;
        border-radius: 8px;
        box-shadow: 0 4px 12px rgba(0,0,0,0.15);
        z-index: 9999;
        animation: slideInRight 0.3s ease;
        max-width: 300px;
        word-wrap: break-word;
    `;
    
    // Add animation keyframes
    if (!document.querySelector('#toast-styles')) {
        const style = document.createElement('style');
        style.id = 'toast-styles';
        style.textContent = `
            @keyframes slideInRight {
                from { transform: translateX(100%); opacity: 0; }
                to { transform: translateX(0); opacity: 1; }
            }
            @keyframes slideOutRight {
                from { transform: translateX(0); opacity: 1; }
                to { transform: translateX(100%); opacity: 0; }
            }
            .toast-content {
                display: flex;
                align-items: center;
                gap: 10px;
            }
        `;
        document.head.appendChild(style);
    }
    
    // Add to page
    document.body.appendChild(toast);
    
    // Auto remove after 4 seconds
    setTimeout(() => {
        toast.style.animation = 'slideOutRight 0.3s ease';
        setTimeout(() => toast.remove(), 300);
    }, 4000);
}

// Helper functions for toast
function getToastIcon(type) {
    const icons = {
        'success': 'check-circle',
        'error': 'exclamation-triangle',
        'warning': 'exclamation-circle',
        'info': 'info-circle'
    };
    return icons[type] || 'info-circle';
}

function getToastColor(type) {
    const colors = {
        'success': '#28a745',
        'error': '#dc3545',
        'warning': '#ffc107',
        'info': '#17a2b8'
    };
    return colors[type] || '#17a2b8';
}

// Accessibility features
function setupAccessibilityFeatures() {
    // Add ARIA labels
    const passwordToggle = document.querySelector('.password-toggle');
    if (passwordToggle) {
        passwordToggle.setAttribute('aria-label', 'Show password');
        passwordToggle.setAttribute('type', 'button');
    }
    
    const captchaRefresh = document.querySelector('.captcha-refresh');
    if (captchaRefresh) {
        captchaRefresh.setAttribute('aria-label', 'Refresh CAPTCHA');
        captchaRefresh.setAttribute('type', 'button');
    }
    
    // Add visible CAPTCHA help text below the CAPTCHA section
    const captchaInput = document.querySelector('input[name*="CaptchaInput"]');
    if (captchaInput) {
        const helpId = 'captcha-help';
        captchaInput.setAttribute('aria-describedby', helpId);

        let helpText = document.getElementById(helpId);
        if (!helpText) {
            // Use <small> for native "help" semantics in forms
            helpText = document.createElement('small');
            helpText.id = helpId;
            helpText.className = 'form-text captcha-help'; // visible help text
            helpText.textContent = 'Enter the 5-character security code shown in the image';
        }

        // Place it directly after the .captcha-container so it appears below image+input
        const formGroup = captchaInput.closest('.form-group');
        const captchaContainer = formGroup ? formGroup.querySelector('.captcha-container') : null;
        if (captchaContainer && helpText.parentElement !== formGroup) {
            captchaContainer.insertAdjacentElement('afterend', helpText);
        } else if (!captchaContainer && helpText.parentElement !== captchaInput.parentElement) {
            captchaInput.parentElement.appendChild(helpText);
        }

        helpText.classList.add('subscript'); // optional
    }
}

// Keyboard navigation
function setupKeyboardNavigation() {
    // Enhanced keyboard navigation for form elements
    const formElements = document.querySelectorAll('input, button, a');
    
    formElements.forEach((element, index) => {
        element.addEventListener('keydown', function(e) {
            // Enter key on buttons
            if (e.key === 'Enter' && element.tagName === 'BUTTON') {
                element.click();
            }
            
            // Arrow keys for navigation (optional enhancement)
            if (e.key === 'ArrowDown' && e.ctrlKey) {
                e.preventDefault();
                const nextElement = formElements[index + 1];
                if (nextElement) nextElement.focus();
            } else if (e.key === 'ArrowUp' && e.ctrlKey) {
                e.preventDefault();
                const prevElement = formElements[index - 1];
                if (prevElement) prevElement.focus();
            }
        });
    });
    
    // Escape key to clear form
    document.addEventListener('keydown', function(e) {
        if (e.key === 'Escape' && e.ctrlKey) {
            const confirmClear = confirm('Are you sure you want to clear the form?');
            if (confirmClear) {
                clearForm();
            }
        }
    });
}

// Clear form function
function clearForm() {
    const form = document.querySelector('.login-form');
    if (form) {
        const inputs = form.querySelectorAll('input[type="text"], input[type="email"], input[type="password"]');
        inputs.forEach(input => {
            input.value = '';
            input.classList.remove('is-valid', 'is-invalid');
        });
        
        const firstInput = inputs[0];
        if (firstInput) firstInput.focus();
        
        showToast('Form cleared', 'info');
    }
}

// Auto-focus first input on page load
$(document).ready(function() {
    const firstInput = document.querySelector('.login-form input:not([type="hidden"])');
    if (firstInput) {
        setTimeout(() => firstInput.focus(), 100);
    }
});

// Browser back button handling
window.addEventListener('pageshow', function(event) {
    if (event.persisted) {
        // Page was loaded from cache, reset form state
        const loginBtn = document.getElementById('loginBtn');
        if (loginBtn) {
            loginBtn.classList.remove('loading');
            loginBtn.disabled = false;
        }
    }
});

// Prevent multiple form submissions
let formSubmitted = false;
$(document).ready(function() {
    $('.login-form').on('submit', function() {
        if (formSubmitted) {
            return false;
        }
        formSubmitted = true;
        
        // Reset flag after 5 seconds (in case of error)
        setTimeout(() => {
            formSubmitted = false;
        }, 5000);
        
        return true;
    });
});