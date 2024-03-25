package sae.android.sae_2a.ui.screen


import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.layout.wrapContentWidth
import androidx.compose.material3.Button
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import sae.android.sae_2a.R


@Composable
fun RegisterScreen(NavigateToApp: () -> Unit ) {
    var name by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }

    Surface(modifier = Modifier
        .wrapContentWidth(align = Alignment.CenterHorizontally)
        .wrapContentHeight(align = Alignment.CenterVertically)
        .fillMaxSize(),) {
        Column(modifier = Modifier
            .background(color = Color.White)
            .wrapContentWidth(align = Alignment.CenterHorizontally)) {

            Image(
                painter = painterResource(id = R.drawable.logo2),
                contentDescription = "Description de l'image",
                modifier = Modifier
                    .wrapContentWidth(align = Alignment.CenterHorizontally)
                    .width(800.dp)
                    .padding(40.dp)
                    .size(width = 200.dp, height = 200.dp)
            )


            TextField(
                value = name,
                onValueChange = { name = it },
                label = { Text("Name") },
                modifier = Modifier.padding(20.dp)
                    .wrapContentWidth(align = Alignment.CenterHorizontally)
                    .align(alignment = Alignment.CenterHorizontally)
            )

            TextField(
                value = password,
                onValueChange = { password = it },
                label = { Text("Name") },
                modifier = Modifier.padding(20.dp)
                    .wrapContentWidth(align = Alignment.CenterHorizontally)
                    .align(alignment = Alignment.CenterHorizontally)
            )

            
            Button(onClick = { NavigateToApp() },modifier = Modifier
                .padding(30.dp)
                .width(150.dp)
                .height(80.dp)
                .align(alignment = Alignment.CenterHorizontally)
                ) {
                Text("Register", fontWeight = FontWeight(1000), fontSize = 24.sp)
            }

        }

    }


}

