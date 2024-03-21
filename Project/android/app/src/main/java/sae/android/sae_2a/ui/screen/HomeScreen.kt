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
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.semantics.Role.Companion.Image
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import sae.android.sae_2a.R
import sae.android.sae_2a.game.VocabularyScreen
import sae.android.sae_2a.ui.screen.RegisterScreen


@Composable
fun MyApp() {
    val navController = rememberNavController()
    NavHost(navController, startDestination = "HomeScreen") {
        composable("HomeScreen") { HomeScreen( NavigateToRegister = { navController.navigate("RegisterScreen")} ,NavigateToLogin = { navController.navigate("VocabularyScreen") }) }
        composable("VocabularyScreen") { VocabularyScreen(onNavigateToList = { navController.navigate("HomeScreen") }) }
        composable("RegisterScreen") { RegisterScreen(NavigateToApp = { navController.navigate("VocabularyScreen") }) }

    }
}


@Composable
fun HomeScreen(NavigateToRegister: () -> Unit,NavigateToLogin: () -> Unit ){


    Surface(modifier = Modifier
            .wrapContentWidth(align = Alignment.CenterHorizontally)
            .wrapContentHeight(align = Alignment.CenterVertically)
            .fillMaxSize(),) {
        Column( modifier = Modifier
                .background(color = Color.Gray)
                .wrapContentWidth(align = Alignment.CenterHorizontally)){
            Image(
                    painter = painterResource(id = R.drawable.logo),
                    contentDescription = "Description de l'image",
                    modifier = Modifier
                        .wrapContentWidth(align = Alignment.CenterHorizontally)
                        .width(800.dp)
                        .padding(40.dp)
                        .size(width = 200.dp, height = 200.dp)
            )
        Text(text ="InEnglishPlease", color = Color.White, fontSize = 30.sp, fontWeight = FontWeight(1000) , modifier = Modifier
                .padding(40.dp)
                .wrapContentHeight(align = Alignment.Top)
                .wrapContentWidth(align = Alignment.CenterHorizontally)
                .align(alignment = Alignment.CenterHorizontally))

            Button( onClick = { NavigateToLogin() }, modifier = Modifier

                    .padding(30.dp)
                    .width(150.dp)
                    .height(80.dp)
                    .align(alignment = Alignment.CenterHorizontally)) {
                Text(text = "Login", fontSize = 20.sp)

            }
            Button(onClick = { NavigateToRegister() },modifier = Modifier
                    .padding(30.dp)
                    .width(150.dp)
                    .height(80.dp)
                    .align(alignment = Alignment.CenterHorizontally)) {
                Text(text = "Register", fontSize = 20.sp)
        }
    }
    }

}