package sae.android.sae_2a.screen

import android.content.res.Resources.Theme
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
import sae.android.sae_2a.R

@Preview
@Composable
fun HomeScreen(){

    Surface(modifier = Modifier
            .wrapContentWidth(align = Alignment.CenterHorizontally)
            .wrapContentHeight(align = Alignment.CenterVertically)
            .fillMaxSize(),) {
        Column( modifier = Modifier
                .background(color = Color.Gray)
                .wrapContentWidth(align = Alignment.CenterHorizontally)){
            Image(
                    painter = painterResource(id = R.drawable.ic_launcher_foreground),
                    contentDescription = "Description de l'image",
                    modifier = Modifier
                            .size(width = 200.dp, height = 200.dp)
                            .padding(16.dp)
            )
        Text(text ="InEnglishPlease", color = Color.White, fontSize = 18.sp, fontWeight = FontWeight(1000) , modifier = Modifier
                .padding(30.dp)
                .wrapContentHeight(align = Alignment.Top)
                .wrapContentWidth(align = Alignment.CenterHorizontally)
                .align(alignment = Alignment.CenterHorizontally))

            Button( onClick = { /*TODO*/ }, modifier = Modifier

                    .padding(15.dp)
                    .width(130.dp)
                    .align(alignment = Alignment.CenterHorizontally)) {
                Text(text = "Login", fontSize = 16.sp)

            }
            Button(onClick = { /*TODO*/ },modifier = Modifier
                    .padding(15.dp)
                    .width(130.dp)
                    .align(alignment = Alignment.CenterHorizontally)) {
                Text(text = "Register", fontSize = 16.sp)
        }
    }
    }

}