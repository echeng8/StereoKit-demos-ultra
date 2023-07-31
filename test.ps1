# Set your API key
$apiKey = "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"

# Endpoint URL
$url = "https://api.openai.com/v1/chat/completions"

# Headers
$headers = @{
    "Content-Type" = "application/json"
    "Authorization" = "Bearer $apiKey"
}

# Body data
$body = @{
    model = "gpt-3.5-turbo"
    messages = @(@{role="user"; content="Say this is a test!"})
    temperature = 0.7
}

# Convert body data to JSON format
$bodyJson = $body | ConvertTo-Json

# Make the request
$response = Invoke-RestMethod -Uri $url -Headers $headers -Method Post -Body $bodyJson

# Print the response
$response
