package sae.android.sae_2a.game

import androidx.compose.foundation.border
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Card
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import sae.android.sae_2a.data.Vocabulary
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.RectangleShape
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.sp
import sae.android.sae_2a.R

@Composable
fun VocabularScreen(
    vocabulary: List<Vocabulary>
){
    DisplayLists(vocabulary)
}

@Composable
fun DisplayLists(vocabulary: List<Vocabulary>) {

}


@Composable
fun VocCard(vocabulary: Vocabulary){
    Card(shape = RectangleShape,
        modifier = Modifier.size(150.dp, 150.dp)) {
        Text(vocabulary.name,
            modifier = Modifier
                .fillMaxWidth()
                .wrapContentHeight()
                .border(2.dp, Color.Blue, shape = RoundedCornerShape(8.dp, 8.dp)),
            fontSize = 20.sp,
            textAlign = TextAlign.Center)
        Text( stringResource(id = R.string.created_by) + (vocabulary.aut ?: stringResource(id = R.string.unknown)))
    }
}

@Preview
@Composable
fun PreviewCard(){
    val laMap = HashMap<String, String>()
    laMap["Fromage"] = "Cheese"
    laMap["Pomme"] = "Apple"
    VocCard(Vocabulary("test","test", laMap))
}