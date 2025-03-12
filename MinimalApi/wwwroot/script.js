async function calculate(operation) {
    const num1 = parseFloat(document.getElementById('num1').value);
    const num2 = parseFloat(document.getElementById('num2').value);

    if (isNaN(num1) || isNaN(num2)) {
        alert("Please enter valid numbers!");
        return;
    }

    try {
        const response = await fetch(`/${operation}?a=${num1}&b=${num2}`);
        if (!response.ok) {
            throw new Error(await response.text());
        }
        const result = await response.json();
        document.getElementById('result').innerText = `Result: ${result}`;
        loadHistory();
    } catch (error) {
        alert(error.message);
    }
}

async function loadHistory() {
    try {
        const response = await fetch("/history");
        if (!response.ok) {
            throw new Error(await response.text());
        }
        const history = await response.json();
        const historyList = document.getElementById('history');
        historyList.innerHTML = history.map(item => `<li>${item}</li>`).join('');
    } catch (error) {
        console.error("Failed to load history:", error);
    }
}

async function clearHistory() {
    try {
        const response = await fetch("/history", { method: 'DELETE' });
        if (!response.ok) {
            throw new Error(await response.text());
        }
        loadHistory();
    } catch (error) {
        console.error("Failed to clear history:", error);
    }
}

loadHistory();