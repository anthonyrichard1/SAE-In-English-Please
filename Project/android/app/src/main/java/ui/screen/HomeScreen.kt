package ui.screen

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.padding
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
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp

@Composable
fun HomeScreen(){
    Surface(modifier = Modifier
        .wrapContentWidth(align = Alignment.CenterHorizontally)
        .wrapContentHeight(align = Alignment.CenterVertically)) {


    Text(text ="InEnglishPlease", modifier = Modifier
        .padding(30.dp)
        .wrapContentHeight(align = Alignment.Top) )
    Column(){
            Button( onClick = { /*TODO*/ }, modifier = Modifier
                .background(color = Color.DarkGray)
                .padding(30.dp)
                .width(100.dp)) {
                Text(text = "Login", fontSize = 20.sp)

            }
            Button(onClick = { /*TODO*/ },modifier = Modifier
                .background(color = Color.DarkGray)
                .padding(30.dp)
                .width(100.dp)) {
                Text(text = "Register", fontSize = 20.sp)
        }
    }
    }

}